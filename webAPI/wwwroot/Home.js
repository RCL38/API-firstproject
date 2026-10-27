
async function signup() {
    const passwordStrength = await checkpassword();
    if (passwordStrength <2) {
        return;
    }
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
async function checkpassword() {
    const password = document.querySelector("#PasswordUp").value
    try {
        const response = await fetch('/api/Password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        });
        if (!response.ok) {
            throw new Error(`errir status:${response.status}`);
        }
        
        const data = await response.json();
        // const currentpassword = json.stringify(data);
        document.querySelector("#PasswordProgress").value = data;

        if (data < 2) {
            alert(`password too low`);
            return data;
        }
        return data;
    }
    catch (e) {
        alert(e.message);
        
    }
    
}