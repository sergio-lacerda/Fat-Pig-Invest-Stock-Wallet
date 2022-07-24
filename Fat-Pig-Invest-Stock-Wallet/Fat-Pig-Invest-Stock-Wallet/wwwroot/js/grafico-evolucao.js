google.charts.load('current', { 'packages': ['bar'] });
google.charts.setOnLoadCallback(drawStuff);

function drawStuff() {
    var data = new google.visualization.arrayToDataTable([
        ['Move', 'Percentage'],
        ["King's pawn (e4)", 44],
        ["Queen's pawn (d4)", 31],
        ["Knight to King 3 (Nf3)", 12],
        ["Queen's bishop pawn (c4)", 10],
        ['Other', 3]
    ]);

    var chartwidth = $('#evolucao-chart').width() - 20;

    var options = {
        width: chartwidth,
        height: chartwidth / 2,
        legend: { position: 'none' },
        axes: {
            x: {
                0: { side: 'top', label: 'R$' } // Top x-axis.
            }
        },
        bar: { groupWidth: "90%" }
    };

    var chart = new google.charts.Bar(document.getElementById('evolucao-chart'));
    // Convert the Classic options to Material options.
    chart.draw(data, google.charts.Bar.convertOptions(options));
};