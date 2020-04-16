using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using PhotonMessage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameServer
{
    class MyClientPeer : ClientPeer
    {
        Hashtable userTabel;
        public MyClientPeer(InitRequest initRequest) : base(initRequest)
        {
            userTabel = new Hashtable();
            userTabel.Add("test1", "123");
            userTabel.Add("test2", "123");
            userTabel.Add("test3", "123");
            userTabel.Add("test4", "123");
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            switch (operationRequest.OperationCode)
            {
                case (byte)OpCodeEnum.Login:
                    string uname = (string)operationRequest.Parameters[(byte)OpKeyEnum.UserName];
                    string pwd = (string)operationRequest.Parameters[(byte)OpKeyEnum.PassWord];

                    if (userTabel.ContainsKey(uname) && userTabel[uname].Equals(pwd))
                    {
                        OperationResponse operation = new OperationResponse(operationRequest.OperationCode);
                        operation.ReturnCode = (short)OpCodeEnum.LoginSuccess;
                        operation.Parameters=new Dictionary<byte, object> { { (byte)OpKeyEnum.UserName, uname } };
                        SendOperationResponse(operation, new SendParameters());
                    }
                    else
                    {
                        OperationResponse operation = new OperationResponse(operationRequest.OperationCode);
                        operation.ReturnCode = (short)OpCodeEnum.LoginFailed;
                        SendOperationResponse(operation, new SendParameters());
                    }
                    break;
            }
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            //throw new NotImplementedException();
        }
    }
}
