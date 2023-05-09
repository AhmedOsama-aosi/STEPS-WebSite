 

export function getchart() {
    new Chart(document.getElementById("bar-chart"), {
        type: 'bar',
        data: {
            labels: ["jun", "feb ", "mar", "Apr", "may", "jun", "jul", "Aug", "sep ", "oct", " Nov", "dec"],
            datasets: [
                {

                    labels: ["jun", "feb ", "mar", "Apr", "may", "jun", "jul", "Aug", "sep ", "oct", " Nov", "dec"],

                    backgroundColor: ["#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429", "#fcc429",],
                    data: [1000, 1500, 1300, 1150, 1250, 1300, 1600, 1400, 1400, 1200, 1100, 1250],

                    label: ["kilo watt"],

                }
            ]
        },
        options: {
            legend: { display: false },
            CharacterData: { display: true },
            title: {
                display: true,
                text: '   electric consimption ',




            },

            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true

                    }
                }]
            }

        }


    });
    
}

