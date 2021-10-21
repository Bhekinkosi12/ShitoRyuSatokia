
var admin = require("firebase-admin");

var serviceAccount = require("path/to/serviceAccountKey.json");

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: "https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com"
});




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












//  https://shitoryukarate-ea3d5-default-rtdb.firebaseio.com/



//storage   gs://shitoryukarate-ea3d5.appspot.com









// Initialize Firebase
firebase.initializeApp(firebaseConfig);
const auth = firebase.auth();
const database = firebase.firestore();
const DB = firebase.database();


database.settings({ timestampsInSnapshots: true });



auth.onAuthStateChanged(user => {
    if (user) {
       
    }
    else {

    }

})


// Signing the user in the database
const signupForm = document.querySelector("#SigninForm");

signupForm.addEventListener('submit', (e) => {
    e.preventDefault();


    const email = signupForm['signin-email'].value;
    const password = signupForm['signin-password'].value;



    auth.createUserWithEmailAndPassword(email, password).then(cred => {
        const model = document.getElementById("signin-Pop");
        model.style.visibility = "initial";



    })



})



// Login User 

const loginForm = document.querySelector('#loginForm');

loginForm.addEventListener('submit', (e) => {

    e.preventDefault();

    const email = loginForm['login-email'].value;
    const password = loginForm['login-password'].value;



    auth.signInWithEmailAndPassword(email, password).then(cred => {
        
    })



})





// Logout user


const logoutBTN = document.getElementById("logout");

logoutBTN.addEventListener('click', (e) => {
    e.preventDefault();

    auth.signOut().then(() => {
        
    })
})
