fetch('employee.json')
  .then((response) => response.json())
  .then((data) => {
    let table = document.getElementById('employeeTable');

    for (let employee of data.employees) {
      let row = document.createElement('tr');
      row.dataset.id = employee.id;

      let firstNameCell = document.createElement('td');
      firstNameCell.textContent = employee.firstName;
      row.appendChild(firstNameCell);

      let lastNameCell = document.createElement('td');
      lastNameCell.textContent = employee.lastName;
      row.appendChild(lastNameCell);

      let netSalaryCell = document.createElement('td');
      netSalaryCell.setAttribute('contenteditable', 'true');
      netSalaryCell.textContent = employee.netSalary;
      row.appendChild(netSalaryCell);

      let assignedTaskCell = document.createElement('td');
      assignedTaskCell.setAttribute('contenteditable', 'true');
      assignedTaskCell.textContent =
        employee.assignedTask || 'No task assigned';
      row.appendChild(assignedTaskCell);

      let actionCell = document.createElement('td');
      let deleteButton = document.createElement('button');
      deleteButton.textContent = 'Delete';
      deleteButton.dataset.id = employee.id;
      deleteButton.classList.add('delete-button');
      deleteButton.addEventListener('click', function () {
        deleteEmployee(employee.id);
      });
      actionCell.appendChild(deleteButton);
      row.appendChild(actionCell);

      table.appendChild(row);

      let actionDeleteCell = document.createElement('td');
      let viewButton = document.createElement('button');
      viewButton.textContent = 'View';
      viewButton.dataset.id = employee.id;
      viewButton.classList.add('view-button');
      viewButton.addEventListener('click', function () {
        viewEmployee(employee.id);
      });
      actionCell.appendChild(viewButton);
      row.appendChild(actionDeleteCell);

      table.appendChild(row);
    }
  })
  .catch((error) => console.error(error));

function deleteEmployee(id) {
  if (confirm('Are you sure you want to delete this employee?')) {
    let table = document.getElementById('employeeTable');
    let row = document.querySelector(`tr[data-id="${id}"]`);

    if (row) {
      table.removeChild(row);
      console.log('Employee with ID ' + id + ' has been deleted.');
    } else {
      console.log('Employee not found.');
    }
  }
}

function viewEmployee(id) {
  fetch('employee.json')
    .then((response) => response.json())
    .then((data) => {
      let employee = data.employees.find((emp) => emp.id === id);

      if (employee) {
        alert(`
          Employee ID: ${employee.id}
          First Name: ${employee.firstName}
          Last Name: ${employee.lastName}
          Net Salary: ${employee.netSalary}
          Assigned Task: ${employee.assignedTask || 'No task assigned'}
        `);
      } else {
        console.log('Employee not found.');
      }
    })
    .catch((error) => console.error(error));
}
