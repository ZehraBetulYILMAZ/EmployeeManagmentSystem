function addEvent() {
  var eventNameInput = document.getElementById('eventName');
  var eventDateInput = document.getElementById('eventDate');
  var eventTypeInput = document.getElementById('eventType');
  var eventInfoInput = document.getElementById('eventInfo');

  var eventName = eventNameInput.value;
  var eventDate = eventDateInput.value;
  var eventType = eventTypeInput.value;
  var eventInfo = eventInfoInput.value;

  if (eventName && eventDate && eventType) {
    var table = document.getElementById('eventList');
    var row = table.insertRow(-1);
    var eventNameCell = row.insertCell(0);
    var eventDateCell = row.insertCell(1);
    var eventTypeCell = row.insertCell(2);
    var eventInfoCell = row.insertCell(3);
    var attendeesCell = row.insertCell(4);
    var actionCell = row.insertCell(5);
    eventNameCell.innerHTML = eventName;
    eventDateCell.innerHTML = eventDate;
    eventTypeCell.innerHTML = eventType;
    eventInfoCell.innerHTML = eventInfo;
    attendeesCell.innerHTML = '';
    actionCell.innerHTML =
      '<button class="delete-button" onclick="deleteEvent(this)">Delete</button>';

    eventNameInput.value = '';
    eventDateInput.value = '';
    eventTypeInput.value = 'Meeting';
    eventInfoInput.value = '';
  }
}

function deleteEvent(button) {
  var row = button.parentNode.parentNode;
  var table = row.parentNode;
  table.deleteRow(row.rowIndex);
}
