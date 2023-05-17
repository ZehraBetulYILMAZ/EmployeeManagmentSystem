function addPayroll() {
  var employeeIdInput = document.getElementById('employeeId');
  var grossSalaryInput = document.getElementById('grossSalary');
  var sgkPremiumInput = document.getElementById('sgkPremium');
  var stampTaxInput = document.getElementById('stampTax');
  var muhtasarTaxInput = document.getElementById('muhtasarTax');

  var employeeId = employeeIdInput.value;
  var grossSalary = parseFloat(grossSalaryInput.value);
  var sgkPremium = parseFloat(sgkPremiumInput.value);
  var stampTax = parseFloat(stampTaxInput.value);
  var muhtasarTax = parseFloat(muhtasarTaxInput.value);

  if (employeeId && grossSalary && sgkPremium && stampTax && muhtasarTax) {
    var deductionsTotal = sgkPremium + stampTax + muhtasarTax;
    var netSalary = grossSalary - deductionsTotal;

    if (netSalary >= 0) {
      var table = document.getElementById('payrollList');
      var row = table.insertRow(-1);
      var employeeIdCell = row.insertCell(0);
      var grossSalaryCell = row.insertCell(1);
      var sgkPremiumCell = row.insertCell(2);
      var stampTaxCell = row.insertCell(3);
      var muhtasarTaxCell = row.insertCell(4);
      var deductionsTotalCell = row.insertCell(5);
      var netSalaryCell = row.insertCell(6);
      var actionCell = row.insertCell(7);

      employeeIdCell.innerHTML = employeeId;
      grossSalaryCell.innerHTML = grossSalary;
      sgkPremiumCell.innerHTML = sgkPremium;
      stampTaxCell.innerHTML = stampTax;
      muhtasarTaxCell.innerHTML = muhtasarTax;
      deductionsTotalCell.innerHTML = deductionsTotal;
      netSalaryCell.innerHTML = netSalary;
      actionCell.innerHTML =
        '<button class="delete-button" onclick="deletePayroll(this)">Delete</button>';
    } else {
      alert('Net Salary cannot be negative!');
    }

    employeeIdInput.value = '';
    grossSalaryInput.value = '';
    sgkPremiumInput.value = '';
    stampTaxInput.value = '';
    muhtasarTaxInput.value = '';
  }
}

function deletePayroll(button) {
  var row = button.parentNode.parentNode;
  var table = row.parentNode;
  table.deleteRow(row.rowIndex);
}

function deletePayroll(button) {
  var row = button.parentNode.parentNode;
  var table = row.parentNode;
  table.deleteRow(row.rowIndex);
}
