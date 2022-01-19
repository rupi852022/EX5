////$(document).ready(function () {

////    $("#singIn").on("click", function () {
////        $("#popupIn").css("display", "block");
////    });

////    $("#singUp").on("click", function () {
////        $("#popupUp").css("display", "block");
////    });

/////*    $("#NewUserSingInForm").submit(handelSubmitIn);*/
////    $("#NewUserSingUpForm").submit(handelSubmitUp);
////});

function closeForm() {
    $("#popupIn").css("display", "none");
    $("#popupUp").css("display", "none");
    $("#ErrorIn").html("");
    $("#ErrorUp").html("");
}

function handelSubmitIn() {
    let UserEmailIn = $("#UserEmailIn").val();
    let UserPasswordIn = $("#UserPasswordIn").val();

    let url = "../api/Users?email=" + UserEmailIn + "&password=" + UserPasswordIn;
    ajaxCall("GET", url, "", userSecsses, UserError);

    return false;

}

function userSecsses(user) {
    console.log(user);
    if (user.Email == null) {
        let error = "<p>שם משתמש או ססמא לא נכונים</p>";
        $("#ErrorIn").html(error);
    }
    else
    {
        localStorage.setItem('UserIn', JSON.stringify(user));
        userIn();
    }
}

function UserError(err) {
    console.log(err);
}


$(document).ready(function () {
    if (localStorage.getItem('UserIn') === null) {
        userOut();
    }
    else {
        userIn();
    }
});


function handelSubmitUp() {
    let UserFname = $("#UserFname").val();
    let UserLname = $("#UserLname").val();
    if ($("#UserbDate").val() == "") {
        var UserbDate = "1/1/1900";
    }
    else {
        let bdate = $("#UserbDate").val().split(' ');
        var UserbDate = bdate[0];
    }
    let UserEmailUp = $("#UserEmailUp").val();
    let UserPasswordUp = $("#UserPasswordUp").val();

    let User = {
        FName: UserFname,
        LName: UserLname,
        BirthDate: UserbDate,
        Email: UserEmailUp,
        Password: UserPasswordUp,
    }
    ajaxCall("POST", "../api/Users", JSON.stringify(User), postSuccessUser, postErrorUser);

    return false;
}


function postSuccessUser() {

    let UserEmailUp = $("#UserEmailUp").val();
    let UserPasswordUp = $("#UserPasswordUp").val();

    let url = "../api/Users?email=" + UserEmailUp + "&password=" + UserPasswordUp;
    ajaxCall("GET", url, "", userSecsses, UserError);
}

function postErrorUser() {
     let error = "<p>הינך רשום למערכת עם מייל זה</p>";
    $("#ErrorUp").html(error);
    console.log("error");
}

function userIn() {
    $("#singUp").css("display", "none");
    $("#singIn").css("display", "none");
    $("#singOut").css("display", "block");
    let User = JSON.parse(localStorage.getItem('UserIn'));
    let UserName = User.FName + " " + User.LName;
    console.log(UserName);
    $("#UserName").html(UserName);
    $("#myArt").removeClass("disabled");
    $("#myRev").removeClass("disabled");
    closeForm();
}

function userOut() {
    $("#singOut").css("display", "none");
    $("#singUp").css("display", "block");
    $("#singIn").css("display", "block");
    $("#myArt").addClass("disabled");
    $("#myRev").addClass("disabled");
    /*window.location.href = "insert.html";*/
    if (window.location.pathname != "/HTML/insert.html") {
        window.location.replace("insert.html");
    }

    $("#UserName").html("אורח");
}

function singOut() {
    localStorage.removeItem('UserIn');
    userOut();
}