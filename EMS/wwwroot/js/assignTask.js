document.addEventListener('DOMContentLoaded', function () {
  const assignTaskForm = document.getElementById('assign-task-form');

  assignTaskForm.addEventListener('submit', function (e) {
    e.preventDefault();

    const employeeId = document.getElementById('employee-id').value;
    const assignedTask = document.getElementById('assigned-task').value;

    if (employeeId.length !== 11) {
      alert('Employee ID must be 11 digits.');
      return;
    }

    assignTaskForm.reset();

    // Başarılı mesajını göster
    alert('Task successfully assigned to employee!');
  });
});
