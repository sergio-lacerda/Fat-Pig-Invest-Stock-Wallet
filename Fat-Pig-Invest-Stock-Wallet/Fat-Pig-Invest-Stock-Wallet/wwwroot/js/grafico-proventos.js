google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(updateEarningsChart);

var earningsChartData;
var earningsAuxData;

function drawEarningsChart() {
    earningsAuxData = [['Provento', 'Total']];

    var dados = JSON.parse(earningsChartData);

    for (var reg in dados) {
        var temp = [
            dados[reg].tipoProvento,
            dados[reg].total            
        ];
        earningsAuxData.push(temp);
    }    
    var data = google.visualization.arrayToDataTable(earningsAuxData);    

    var chartwidth = $('#earningschart').width() - 20;

    var formatter = new google.visualization.NumberFormat({
        decimalSymbol: ',',
        groupingSymbol: '.',
        prefix: 'R$ '
    });
    formatter.format(data, 1);

    var options = {
        legend: { position: 'labeled', labeledValueText: 'value' },
        width: chartwidth,
        height: chartwidth / 2,
        chartArea: { width: chartwidth, left: 0, top: 0, height: chartwidth / 2 },
        pieHole: 0.4
    };

    var chart = new google.visualization.PieChart(document.getElementById('earningschart'));
    chart.draw(data, options);
}

function updateEarningsChart() {
    var actionUrl = window.location.origin + '/Admin/pvProventos';

    $.ajax({
        url: actionUrl,
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            earningsChartData = JSON.stringify(data);            
            drawEarningsChart();
            return false;
        }
    });

    return false;
}
