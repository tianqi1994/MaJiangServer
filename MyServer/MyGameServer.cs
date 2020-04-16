using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameServer
{
    public class MyGameServer : ApplicationBase  //继承接口，重写继承方法，注释不必要的异常抛出代码
    {
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            log.Info("Client Request!");
            MyClientPeer pongGamePeer = new MyClientPeer(initRequest);  //创建自己的Peer类对象并返回
            return pongGamePeer;
        }

        protected override void Setup()
        {
            ////日志初始化
            ////ApplicationRootPath为部署服务端程序目录 在这里指的是：E:\PhotonServerSDK\Photon-OnPremise-Server-SDK_v4-0-29-11263\deploy
            //log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");//配置日志输出目录 同下
            ////log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = @"E:\PhotonServerSDK\Photon-OnPremise-Server-SDK_v4-0-29-11263\deploy\log";//配置日志输出目录

            ////BinaryPath为当前程序集的目录 在这里指的是：E:\PhotonServerSDK\Photon-OnPremise-Server-SDK_v4-0-29-11263\deploy\MyGameServer\bin
            //FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            //if (configFileInfo.Exists)
            //{
            //    //告知Photon使用的是log4net日志插件
            //    LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            //    //让log4net插件读取配置文件
            //    XmlConfigurator.ConfigureAndWatch(configFileInfo);
            //}

            //log.Info("SetUp Completed!");
        }

        protected override void TearDown()
        {
            //log.Info("Server is shutdown.");
        }
    }
}
