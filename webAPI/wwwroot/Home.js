
async function signup() {
    const user = {
        firstName: document.querySelector("#First_Name").value,
        lastName: document.querySelector("#Last_Name").value,
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