google.charts.load("current", { packages: ["corechart"] });
google.charts.setOnLoadCallback(updatePizzaChart);

var pizzaChartData;
var pizzaAuxData;

function drawPizzaChart() {
    pizzaAuxData = [['Ação', 'Valor']];

    var dados = JSON.parse(pizzaChartData);

    for (var reg in dados) {
        var temp = [
            dados[reg].acao,
            dados[reg].total            
        ];
        pizzaAuxData.push(temp);
    }
    var data = google.visualization.arrayToDataTable(pizzaAuxData);    

    var chartwidth = $('#piechart_3d').width() - 20;

    var formatter = new google.visualization.NumberFormat({
        decimalSymbol: ',',
        groupingSymbol: '.',
        prefix: 'R$ '
    });
    formatter.format(data, 1);

    var options = {
        legend: { position: 'labeled' },        
        width: chartwidth,
        height: chartwidth / 2,        
        chartArea: { width: chartwidth, left: 0, top: 0, height: chartwidth/2 },
        is3D: true
    };

    var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));
    chart.draw(data, options);
}

function updatePizzaChart() {
    var actionUrl = window.location.origin + '/Admin/pvDistribuicaoAcoes';

    $.ajax({
        url: actionUrl,
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            pizzaChartData = JSON.stringify(data);            
            drawPizzaChart();
            return false;
        }
    });

    return false;
}
