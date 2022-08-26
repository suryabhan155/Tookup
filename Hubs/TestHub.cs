using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOL;

using Microsoft.AspNet.SignalR;
namespace UI.Hubs
{
    public class MyHub : Hub
    {
        //public override bool Equals(object obj)
        //{
        //    return base.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

        //public override Task OnConnected()
        //{

        //    Clients.Caller.SendAsync("Connected", Context.ConnectionId);
        //    return base.OnConnected();
        //}

        //public override Task OnDisconnected(bool b)
        //{
        //    return base.OnDisconnected(b);
        //}

        //public override string ToString()
        //{
        //    return base.ToString();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);
        //}

        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }

        public override Task OnConnected()
        {
            //Use Application.Current.Dispatcher to access UI thread from outside the MainWindow class
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            
            return base.OnDisconnected(stopCalled);
        }
    }
}

