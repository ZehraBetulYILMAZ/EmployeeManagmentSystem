function login() {
  var usernameInput = document.getElementById('username');
  var passwordInput = document.getElementById('password');
  var username = usernameInput.value;
  var password = passwordInput.value;

  if (username === 'admin' && password === 'password') {
    window.location.href = 'admin.html';
  } else {
    alert('Invalid username or password. Please try again.');
  }

  usernameInput.value = '';
  passwordInput.value = '';
}
