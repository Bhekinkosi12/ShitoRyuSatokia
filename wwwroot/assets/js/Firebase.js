
var admin = require("firebase-admin");

var serviceAccount = require("path/to/serviceAccountKey.json");

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: "https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com"
});



// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
    apiKey: "AIzaSyBeDXvk3UC_Wj5WUf8ylIFYfH3nA-5tCcQ",
    authDomain: "shitoryukarate-ea3d5.firebaseapp.com",
    databaseURL: "https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com",
    projectId: "shitoryukarate-ea3d5",
    storageBucket: "shitoryukarate-ea3d5.appspot.com",
    messagingSenderId: "148181986245",
    appId: "1:148181986245:web:7b615e0c05583e3985f9ac",
    measurementId: "G-NP36RK5ED3"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);


//  https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com/



//storage   gs://shitoryukarate-ea3d5.appspot.com