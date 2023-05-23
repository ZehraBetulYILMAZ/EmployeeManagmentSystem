document.addEventListener('DOMContentLoaded', function () {
  const form = document.getElementById('new-employee-form');
  form.addEventListener('submit', function (e) {
    e.preventDefault(); // Formun varsayılan gönderimini engelle

    // Formdaki değerleri al
    const identificationNumber = document.getElementById(
      'identification-number'
    ).value;
    const firstName = document.getElementById('first-name').value;
    const lastName = document.getElementById('last-name').value;
    const birthdate = document.getElementById('birthdate').value;
    const address = document.getElementById('address').value;
    const gender = document.getElementById('gender').value;
    const department = document.getElementById('department').value;
    const assignedTask = document.getElementById('assigned-task').value;
    const netSalary = document.getElementById('net-salary').value;

    // İdentiification number 11 haneli değilse hata mesajı göster
    if (identificationNumber.length !== 11) {
      alert('Id number must be 11 digits.');
      return;
    }

    // Doğum tarihi kontrolü
    const today = new Date();
    const selectedDate = new Date(birthdate);
    const age = today.getFullYear() - selectedDate.getFullYear();

    if (age < 18) {
      alert('Employee must be 18 or older.');
      return;
    }

    // Tüm bilgiler doğru ise başarılı mesajını göster
    alert('New Employee Successfully Added!');
  });
  form.reset();
});
