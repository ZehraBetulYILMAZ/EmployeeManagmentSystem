document.getElementById('upload').addEventListener('submit', function (event) {
  event.preventDefault(); // Formun varsayılan davranışını engelle

  // Dosya seçimi
  const fileInput = document.getElementById('file-input');
  const file = fileInput.files[0];

  // Dosya yükleme işlemi gerçekleştirildiğinde
  // Burada yükleme işlemlerini gerçekleştirebilirsiniz
  // Örnek olarak, dosyayı bir sunucuya göndermek için AJAX veya Fetch kullanabilirsiniz

  // Simüle edilmiş yükleme süresi
  setTimeout(function () {
    // Yükleme işlemi tamamlandığında
    // Alert mesajını görüntüle
    alert('File Uploaded Successfully');

    // Dosya seçim alanını temizle
    fileInput.value = '';
  }, 2000); // 2 saniye sonra tamamlanmış gibi simüle ediyoruz
});
