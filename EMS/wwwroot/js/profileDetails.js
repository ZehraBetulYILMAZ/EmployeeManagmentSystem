document.addEventListener('DOMContentLoaded', function () {
  fetch('employee.json')
    .then((response) => response.json())
    .then((data) => {
      const employee = data.employees.find(
        (emp) => emp.identificationNumber === '3216549870'
      );

      if (employee) {
        document.getElementById('identification-number').innerText =
          employee.identificationNumber;
        document.getElementById('first-name').innerText = employee.firstName;
        document.getElementById('last-name').innerText = employee.lastName;
        document.getElementById('birthdate').innerText = employee.birthday;
        document.getElementById('address').innerText = employee.address;
        document.getElementById('gender').innerText = employee.gender;
        document.getElementById('department').innerText = employee.department;
        document.getElementById('assigned-task').innerText =
          employee.assignedTask;
        const taskStatus = document.getElementById('task-status');
        taskStatus.value = employee.taskStatus;
      }
    })
    .catch((error) => {
      console.log('Error fetching employee data:', error);
    });
});

function changeTaskStatus() {
  const taskStatus = document.getElementById('task-status');
  const selectedStatus = taskStatus.value;

  if (selectedStatus === 'Not Done')
    alert('Status Changed Succesfully to Not Done');
  if (selectedStatus === 'On Progress')
    alert('Status Changed Succesfully to On Progress');
  if (selectedStatus === 'Completed')
    alert('Status Changed Succesfully to Completed');
}
