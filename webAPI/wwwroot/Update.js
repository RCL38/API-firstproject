
console.log("דדדד")
const user1 = JSON.parse(sessionStorage.getItem("user"));

console.log(user1)

const email = document.querySelector("#UserName");
const password = document.querySelector("#PasswordUp");
const firstname = document.querySelector("#FirstName");
const lastname = document.querySelector("#LastName");

email.value = user1.email;
password.value = user1.password;
firstname.value = user1.firstname;
lastname.value = user1.lastname;


async function update() {

    
    const id = user1.userId;

    const email = document.querySelector("#UserName").value;
    const password = document.querySelector("#PasswordUp").value;
    const firstname = document.querySelector("#FirstName").value;
    const lastname = document.querySelector("#LastName").value;
   

    const loginUser = {
        email,
        password,
        firstname,
        lastname,
    };
    
    
    
    const response = await fetch(`/api/Users/${id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(loginUser)
    });

    if (response.ok) {
        // const user = await response.json();
        alert("changes has bben changed! ")// + user.firstName);
    }
    else {
        alert("update failed");
    }
}