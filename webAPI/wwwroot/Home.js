
async function signup() {

    const user = {
        firstname: document.querySelector("#First_Name").value,
        lastname: document.querySelector("#Last_Name").value,
        email: document.querySelector("#UserNameUp").value,
        password: document.querySelector("#PasswordUp").value
    };


    const response = await fetch('/api/Users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });

    if (response.ok) {
        alert("User registered successfully!");
    }
    else {
        alert("Registration failed");
    }

}
async function checkPasswordSrtength() {
    const password = document.querySelector("#PasswordUp").value;
    if (!password) {
        //const pass = document.querySelector("#password-info").value = "enteryourpassword";
        alert("enter your password");
        return;
    }
    try {
        const response = await fetch('/api/Users/password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password),
        });

        if (!response.ok) {
            throw new Error(`error ststus: ${response.status}`);
        }
        const data = await response.json();
        const currentPassword = JSON.stringify(data);
        document.querySelector("#passProgress").value = currentPassword

        if (currentPassword < 2) {
            //const pass = document.querySelector("#password-info").value = "too low";
            alert("too low")
        }
    }
    catch (error) {
        alert(error.message);
    }



}

async function signin() {

    const UserName = document.querySelector("#UserName").value;
    const Password = document.querySelector("#PasswordIn").value;

    const loginUser = {
        email: UserName,
        password: Password
    };

    const response = await fetch('/api/Users/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginUser)
    });

    if (response.ok) {
        const user = await response.json();
        sessionStorage.setItem("user", JSON.stringify(user));
        alert("welcome " + user.firstName);
    }
    else {
        alert("Incorrect email or password");
    }
}