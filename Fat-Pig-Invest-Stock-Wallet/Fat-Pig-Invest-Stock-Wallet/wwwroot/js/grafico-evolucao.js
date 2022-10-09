google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(updateBarChart);

var barChartData;
var barAuxData;

function drawBarChart() {
    barAuxData = [['Data', 'Acumulado']];

    let dados = JSON.parse(barChartData);
    let acumulado = 0;

    for (let reg in dados) {
        acumulado += (dados[reg].compras - dados[reg].vendas)        
        let temp = [
            new Date(dados[reg].dataPregao).toLocaleDateString(),            
            acumulado
        ];
        barAuxData.push(temp);
    }
    let data = new google.visualization.arrayToDataTable(barAuxData);

    var chartwidth = $('#evolucao-chart').width() - 20;

    var options = {
        width: chartwidth,
        height: chartwidth / 2,
        legend: { position: 'none' },        
        bar: { groupWidth: "90%" }        
    };

    var chart = new google.charts.Bar(document.getElementById('evolucao-chart'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
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