using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using DECIS.Utilities;
using System;
using System.Threading.Tasks;

namespace DECIS.Importing
{
    public class AmazonUploader
    {
        IAmazonS3 client = new AmazonS3Client(RegionEndpoint.USEast2);

        public bool UploadFileToS3Public(System.IO.Stream fs, string alias, string key, out string path, string folder = "")
        {
            key = key.Substring(0, 10);
            if (folder != "")
                key = $"{folder}/{key}";

            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = alias;
            request.Key = key; //file name  
            request.InputStream = fs;
            utility.Upload(request); //commensing the transfer  
            var response = client.GetObject(alias ,key);
            var code = response.HttpStatusCode;
            path = $"https://{alias}.s3.us-east-2.amazonaws.com/{key}"; //public url format for s3 (don store sensitive info here)
            if (code == System.Net.HttpStatusCode.OK)
                return true; //indicate that the file was sent  
            else
                return false;
        }

        public bool UploadFileToS3Private(System.IO.Stream fs, string alias, string key, out string path, string folder = "")
        {
            key = key.Substring(0, 10);
            key += RandomizeString.RandomString(5);
            if (folder != "")
                key = $"{folder}/{key}";

            TransferUtility utility = new TransferUtility(client);
            TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
            request.BucketName = alias;
            request.Key = key; //file name  
            request.InputStream = fs;
            utility.Upload(request); //commensing the transfer  
            var response = client.GetObject(alias, key);
            var code = response.HttpStatusCode;

            path = $"{alias},{key}"; //URL links are temporary so we need to generate it each time with these values
            if (code == System.Net.HttpStatusCode.OK)
                return true; //indicate that the file was sent  
            else
                return false;
        }
        /// <summary>
        /// Get a valid link to the image
        /// </summary>
        /// <param name="path">The alias/key of the bucket/file for private buckets(spreadsheets)</param>
        /// <returns>a valid temporary url</returns>
        public static string GetURL(string path)
        {
            IAmazonS3 client = new AmazonS3Client(RegionEndpoint.USEast2);
            string[] values = path.Split(',');
            string alias = values[0];
            string key = values[1];
            GetPreSignedUrlRequest request = new GetPreSignedUrlRequest();
            request.BucketName = alias;
            request.Key = key;
            request.Expires = DateTime.Now.AddHours(1);
            request.Protocol = Protocol.HTTP;
            return client.GetPreSignedURL(request);
        }


    }
}