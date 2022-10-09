google.charts.load("current", { packages: ['corechart'] });
google.charts.setOnLoadCallback(updateBarChart);

var barChartData;
var barAuxData;

function drawBarChart() {
    barAuxData = [['Data', 'Acumulado', { role: 'annotation' }]];

    let dados = JSON.parse(barChartData);
    let acumulado = 0;

    for (let reg in dados) {
        acumulado += (dados[reg].compras - dados[reg].vendas)        
        let temp = [
            new Date(dados[reg].dataPregao).toLocaleDateString(),            
            acumulado,
            'R$ ' + acumulado.toLocaleString('pt-br', { minimumFractionDigits: 2 })
        ];
        barAuxData.push(temp);
    }
    // Showing last 5 values in the chart
    if (barAuxData.length > 6)
        barAuxData.splice(1, barAuxData.length - 6);

    // Setting zero when no values are provided
    if (barAuxData.length < 2)
        barAuxData.push([new Date(Date.now()).toLocaleDateString(), 0, 'R$ 0,00']);

    let data = new google.visualization.arrayToDataTable(barAuxData);

    var chartwidth = $('#evolucao-chart').width() - 20;

    var formatter = new google.visualization.NumberFormat({
        decimalSymbol: ',',
        groupingSymbol: '.',
        prefix: 'R$ '
    });
    formatter.format(data, 1);

    var options = {
        width: chartwidth,
        height: chartwidth / 2,
        legend: { position: 'bottom' },        
        bar: { groupWidth: "90%" },
        chartArea: { width: chartwidth, left: 0, top: 0, height: (chartwidth / 2)-50 }
    };
       
    var chart = new google.visualization.ColumnChart(document.getElementById("evolucao-chart"));
    chart.draw(data, options);
};

function updateBarChart() {
    var actionUrl = window.location.origin + '/Admin/pvEvolucaoPatrimonial';

    $.ajax({
        url: actionUrl,
        type: 'POST',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            barChartData = JSON.stringify(data);            
            drawBarChart();
            return false;
        }
    });

    return false;
}