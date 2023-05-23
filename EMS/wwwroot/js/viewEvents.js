document.addEventListener('DOMContentLoaded', function () {
  fetch('events.json')
    .then((response) => response.json())
    .then((data) => {
      const eventList = document.getElementById('event-list');

      data.events.forEach((event) => {
        const row = document.createElement('tr');
        row.innerHTML = `
          <td>${event.eventName}</td>
          <td>${event.eventDate}</td>
          <td>${event.eventType}</td>
          <td>${event.eventInfo}</td>
          <td>${event.attendees.join(', ')}</td>
          <td class="action-buttons">
          <button class="green-button" onclick=attendEvent() data-id="${
            event.id
          }">Attend</button>
          <button class="leave-button"
          onclick=leaveEvent()  data-id="${event.id}">Leave Event</button>
          </td>
        `;

        eventList.appendChild(row);
      });
    })
    .catch((error) => {
      console.log('Error fetching event data:', error);
    });
});

function attendEvent() {
  if (confirm('Are you really want to attend this event ?')) {
    alert('Successfully attended to the Event ! ');
  }
}

function leaveEvent() {
  if (confirm('Are you really want to leave this event ?')) {
    alert('Successfully Leave the Event !');
  }
}
