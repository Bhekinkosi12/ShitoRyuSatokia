using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShitoRyuSatokia.Services
{
    public class UserStorage
    {


        public  FirebaseStorageTask AddStoreStream(string name, Stream stream)
        {
            return new FirebaseStorage("shitoryukarate-ea3d5.appspot.com")
                .Child("Compony")
                
                .Child(name)
                .PutAsync(stream);



           
        }
    }
}
