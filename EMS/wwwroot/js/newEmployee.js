var newEmployeeForm = document.getElementById('newEmployeeForm');

newEmployeeForm.addEventListener('submit', function (event) {
  event.preventDefault();

  var firstName = document.getElementById('firstName').value;
  var lastName = document.getElementById('lastName').value;
  var birthDate = document.getElementById('birthDate').value;
  var identificationNumber = document.getElementById(
    'identificationNumber'
  ).value;

  // Perform necessary actions with the form data (e.g., save to database)

  // Reset the form
  newEmployeeForm.reset();

  alert(
    'New employee added:\n\nFirst Name: ' +
      firstName +
      '\nLast Name: ' +
      lastName +
      '\nBirth Date: ' +
      birthDate
  );
});
