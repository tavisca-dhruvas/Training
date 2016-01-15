﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Model
{
    class Response
    {

        RegistryKey registryKey = Registry.ClassesRoot;
        public Socket ClientSocket = null;
        private Encoding _charEncoder = Encoding.UTF8;
        private string _contentPath;
        private FileHandler FileHandler;

        public Response(Socket clientSocket, string contentPath)
        {
            _contentPath = contentPath;
            ClientSocket = clientSocket;
            FileHandler = new FileHandler(_contentPath);
        }

        public void RequestUrl(string requestedFile)
        {
            int dotIndex = requestedFile.LastIndexOf('.') + 1;
            if (dotIndex > 0)
            {
                if (FileHandler.DoesFileExists(requestedFile))   
                    SendResponse(ClientSocket, FileHandler.ReadFile(requestedFile), "200 Ok", GetTypeOfFile(registryKey, (_contentPath + requestedFile)));
                else
                    SendErrorResponce(ClientSocket);     
            }
            else   
            {
                if (FileHandler.DoesFileExists("\\index.htm"))
                    SendResponse(ClientSocket, FileHandler.ReadFile("\\index.htm"), "200 Ok", "text/html");
                else if (FileHandler.DoesFileExists("\\index.html"))
                    SendResponse(ClientSocket, FileHandler.ReadFile("\\index.html"), "200 Ok", "text/html");
                else
                    SendErrorResponce(ClientSocket);
            }
        }

        private string GetTypeOfFile(RegistryKey registryKey, string fileName)
        {
            RegistryKey fileClass = registryKey.OpenSubKey(Path.GetExtension(fileName));
            string type = "";
            try
            {
                type = fileClass.GetValue("Content Type").ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return type;
        }

        private void SendErrorResponce(Socket clientSocket)
        {
            SendResponse(clientSocket, new byte[] { Convert.ToByte(' ') }, "404 Not Found", "text/html");
        }


        private void SendResponse(Socket clientSocket, byte[] byteContent, string responseCode, string contentType)
        {
            try
            {
                byte[] byteHeader = CreateHeader(responseCode, byteContent.Length, contentType);
                clientSocket.Send(byteContent);
                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private byte[] CreateHeader(string responseCode, int contentLength, string contentType)
        {
            return _charEncoder.GetBytes("HTTP/1.1 " + responseCode + "\r\n"
                                  + "Server: Dhruva's Web Server\r\n"
                                  + "Content-Length: " + contentLength + "\r\n"
                                  + "Connection: close\r\n"
                                  + "Content-Type: " + contentType + "\r\n\r\n");
        }

    }
}