function login() {
    var usernameInput = document.getElementById('username');
    var passwordInput = document.getElementById('password');
    var username = usernameInput.value;
    var password = passwordInput.value;

    if (username === '' && password === '') {
        alert('Invalid username or password. Please try again.');
    }

 
}
