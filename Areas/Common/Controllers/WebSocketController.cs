using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TookUp.BOL.ViewModels.CommonModels;
using System.Collections.Concurrent;
using System.Threading;
using UI.Areas.Common.Data;
using System.Diagnostics;
using LitJson;
using System.Threading.Tasks;
using System.Drawing;
using System.Web;
using System.IO;
using NAudio.Wave;
using NAudio.CoreAudioApi;

namespace UI.Areas.Common.Controllers
{
    //[RoutePrefix("api/server")]
    [Authorize]
    public class WebSocketController : ApiController
    {
        public readonly CancellationTokenSource Cancel;
        public WebSocketController()
        {
            Cancel = new CancellationTokenSource();
        }
        HttpResponseMessage responsemsg = null;
        ResponseModel response;
        public readonly ConcurrentDictionary<Guid, WebSocketController> Streams = new ConcurrentDictionary<Guid, WebSocketController>();

        [Route("api/server/connect")]
        [HttpPost]
        public HttpResponseMessage connect()
        {
            response = null;
            try
            {
                //Program.Main();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Request.CreateResponse(HttpStatusCode.OK, "server connected......");
        }

        [HttpPost]
        public HttpResponseMessage RenderStream()
        {
            try
            {
                response = null;
                response.success = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }
        // List of Video Devices Available.
        [Route("api/Socket/videodevices")]
        [HttpPost]
        public HttpResponseMessage GetVideoDevice()
        {
            try
            {
                response = null;
                List<string> videodevice = null;
                //var videodevices = cameraobj.GetCameraSources();
                if (videodevice.Count == 0)
                {
                    response.message = "No Video Devices";
                    response.data = null;
                    response.success = true;
                }
                else
                {
                    response.message = "List of Video Devices";
                    response.data = videodevice;
                    response.success = true;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.data = "";
                response.success = false;
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        //capturing system audio
        [HttpPost]
        public HttpResponseMessage CaptureSystemAudio()
        {
            try
            {
                response = null;
                // Define the output folder of the recorded audio
                var outputFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Audio");
                Directory.CreateDirectory(outputFolder);
                var outputFilePath = Path.Combine(outputFolder, "recorded.wav");
                // Redefine the capturer instance with a new instance of the LoopbackCapture class
                var capture = new WasapiLoopbackCapture();
                // Redefine the audio writer instance with the given configuration
                var writer = new WaveFileWriter(outputFilePath, capture.WaveFormat);
                // When the capturer receives audio, start writing the buffer into the mentioned file
                capture.DataAvailable += (s, a) =>
                {
                    writer.Write(a.Buffer, 0, a.BytesRecorded);
                    if (writer.Position > capture.WaveFormat.AverageBytesPerSecond * 20)
                    {
                        capture.StopRecording();
                    }
                };
                // When the Capturer Stops
                capture.RecordingStopped += (s, a) =>
                {
                    writer.Dispose();
                    writer = null;
                    capture.Dispose();
                };
                // Start recording !
                capture.StartRecording();
                while (capture.CaptureState != NAudio.CoreAudioApi.CaptureState.Stopped)
                {
                    Thread.Sleep(500);
                }
                response.message = "Recorded successfully";
                response.data = "File recorded at " + outputFolder;
                response.success = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        //Enumerating Audio Devices
        [HttpPost]
        public HttpResponseMessage AudioDevice()
        {
            try
            {
                List<string> l1 = null;
                response = null;
                // List of devices.
                var enumerator = new MMDeviceEnumerator();
                foreach (var wasapi in enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.All))
                {
                    Console.WriteLine($"{wasapi.DataFlow} {wasapi.FriendlyName} {wasapi.DeviceFriendlyName} {wasapi.State}");
                    l1.Add(wasapi.FriendlyName);
                }
                //open the device 
                //var outputDevice = new WasapiOut(mmDevice, ...);
                //var recordingDevice = new WasapiIn(captureDevice, ...);
                //var loopbackCapture = new WasapiLoopbackCapture(loopbackDevice);
                enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
                response.message = "Audio devices";
                response.data = l1;
                response.success = true;
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
            }
            responsemsg = Request.CreateResponse(response);
            return responsemsg;
        }

        // playing with audio devices
        public void playsound()
        {
            using (var audioFile = new AudioFileReader("audioFile"))
            using (var outputDevice = new WasapiOut())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
        // LEAVE computer audio
        public void leavecomputersound()
        {
            using (var audioFile = new AudioFileReader("audioFile"))
            using (var outputDevice = new WasapiOut())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
