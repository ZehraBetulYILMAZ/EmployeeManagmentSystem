document.addEventListener('DOMContentLoaded', function () {
  fetch('employee.json')
    .then((response) => response.json())
    .then((data) => {
      const employeeList = document.getElementById('employee-list');

      data.employees.forEach((employee) => {
        const row = document.createElement('tr');
        row.innerHTML = `
          <td>${employee.firstName}</td>
          <td>${employee.lastName}</td>
          <td>${employee.gender}</td>
          <td>${employee.birthday}</td>
          <td>${employee.address}</td>
          <td>${employee.department}</td>
          <td>${employee.netSalary}</td>
          <td>${employee.assignedTask}</td>
          <td>${employee.taskStatus}</td>
          <td class="action-buttons">
          <button class="delete-button" data-id="${employee.id}">Delete</button>
          </td>
        `;

        employeeList.appendChild(row);
      });

      // Delete button event listener
      const deleteButtons = document.querySelectorAll('.delete-button');
      deleteButtons.forEach((button) => {
        button.addEventListener('click', deleteEmployee);
      });
    })
    .catch((error) => {
      console.log('Error fetching employee data:', error);
    });
});

function deleteEmployee(event) {
  const confirmDelete = confirm(
    'Are you sure you want to delete this employee?'
  );
  if (confirmDelete) {
    const button = event.target;
    const row = button.parentNode.parentNode;
    row.parentNode.removeChild(row);
  }
}
