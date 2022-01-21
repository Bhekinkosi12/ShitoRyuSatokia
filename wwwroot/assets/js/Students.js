var S_Signup = document.getElementById("createACC");
var Fr_login = document.getElementById("loginn");
var Fr_signin = document.getElementById("signinn");


S_Signup.addEventListener("onclick", () => {
    Fr_login.style.visibility = "hidden";
    Fr_login.style.display = "none";
    Fr_signin.style.visibility = "initial";
});



function ShowSignUp(isShow) {
    if (isShow) {
        Fr_login.style.visibility = "hidden";
        Fr_signin.style.visibility = "initial";
        Fr_login.style.display = "none";
        Fr_signin.style.display = "initial";
    }
    else {
        Fr_login.style.visibility = "initial";
        Fr_signin.style.visibility = "hidden";
        Fr_login.style.display = "initial";
        Fr_signin.style.display = "none";
    }
}