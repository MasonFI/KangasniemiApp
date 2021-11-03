const myChart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: chartLabels,
        datasets: [
            {
                label: '0-14',
                data: chartData[0],
                borderWidth: 1,
                backgroundColor: 'blue'
            },
            {
                label: '15-64',
                data: chartData[1],
                borderWidth: 1,
                backgroundColor: 'green'
            },
            {
                label: '65+',
                data: chartData[2],
                borderWidth: 1,
                backgroundColor: 'red'
            }
        ]
    },
    options: {
        scales: {
            x: {
                stacked: true
            },
            y: {
                stacked: true,
                beginAtZero: true
            }
        },
        plugins: {
            title: {
                display: true,
                text: chartLegend,
            }
        }
    }
});