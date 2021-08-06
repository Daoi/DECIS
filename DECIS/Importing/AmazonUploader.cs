using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System;

namespace DECIS.Importing
{
    public class AmazonUploader
    {
        IAmazonS3 client = new AmazonS3Client(RegionEndpoint.USEast2);

        public bool sendMyFileToS3Async(System.IO.Stream localFilePath, string alias, string fileNameInS3, out string path)
        {
            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

            request.BucketName = alias;
            request.Key = fileNameInS3; //file name up in S3  
            request.InputStream = localFilePath;
            utility.Upload(request); //commensing the transfer  
            client.GetObject(alias ,fileNameInS3);

            path = GetURL(alias, fileNameInS3);

            return true; //indicate that the file was sent  
        }

        private string GetURL(string alias, string key)
        {
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest();
            request.BucketName = alias;
            request.Key = key;
            request.Expires = DateTime.Now.AddHours(1);
            request.Protocol = Protocol.HTTP;
            return client.GetPreSignedURL(request);
        }
    }
}