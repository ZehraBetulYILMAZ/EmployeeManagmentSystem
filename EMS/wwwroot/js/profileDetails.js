function showProfileDetails() {
  // Çalışan verilerini almak için AJAX isteği yapalım
  fetch('employee.json')
    .then((response) => response.json())
    .then((data) => {
      // İlgili çalışanın bilgilerini bulmak için örneğin bir id kullanabiliriz
      const employeeId = 1; // Örnek olarak 1. çalışanın bilgilerini alalım

      // Çalışanın bilgilerini bulalım
      const employee = data.employees.find((emp) => emp.id === employeeId);

      // Profil ayrıntılarını oluşturalım
      const profileInfoDiv = document.getElementById('profileInfo');
      profileInfoDiv.innerHTML = `
        <p><strong>Name:</strong> ${employee.firstName} ${employee.lastName}</p>
        <p><strong>Birthday:</strong> ${employee.birthday}</p>
        <p><strong>Net Salary:</strong> ${employee.netSalary}</p>
        <p><strong>Assigned Task:</strong> ${employee.assignedTask}</p>
      `;
    })
    .catch((error) => console.error(error));
}
