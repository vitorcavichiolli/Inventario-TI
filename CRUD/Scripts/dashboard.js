function gerarGrafico() {

    $.ajax({
        url: '/Home/GetChartTiposDispositivos/',
        type: 'POST',
        async: false,
        success: function (result) {
            result = JSON.parse(result);
            var cores = [];
            var qtds = result.Quantidade;
            for (var i = 0; i <= Object.keys(qtds).length - 1; i++) {
                cores.push(gerarCor());
            }
            const data = {
                labels: result.Tipos,
                datasets: [{
                    data: qtds,
                    backgroundColor: cores,
                    hoverOffset: 4
                }]
            };
            const config = {
                type: 'doughnut',
                data: data,
                options: {
                    maintainAspectRatio: false,
                    responsive: true,
                    legend: {
                        labels: {
                            color: 'white'
                        }
                    },
                    plugins: {
                        title: {
                            display: true,
                            text: 'Tipos de Dispositivos',
                            color: 'white'
                        },
                        legend: {
                            display: true,
                            labels: {
                                color: 'white'
                            }
                        }
                    }
                }
            };

            const myChart = new Chart(document.getElementById('myChart'), config);
        }
    });
}

function gerarChartAtivoInativo() {
    $.ajax({
        url: '/Home/GetChartAtivosInativos/',
        type: 'POST',
        async: false,
        success: function (result) {
            result = JSON.parse(result);
            var cor1 = '#3498db';
            var cor2 = '#e74c3c';
            const labels = ['JANEIRO', 'FEVEREIRO', 'MARÇO', 'ABRIL', 'MAIO', 'JUNHO', 'JULHO', 'AGOSTO', 'SETEMBRO', 'OUTUBRO', 'NOVEMBRO', 'DEZEMBRO'];
            const data = {
                labels: labels,
                datasets: [
                    {
                        label: 'ATIVOS',
                        data: result.Ativos,
                        borderColor: cor1,
                        backgroundColor: cor1,
                    },
                    {
                        label: 'INATIVOS',
                        data: result.Inativos,
                        borderColor: cor2,
                        backgroundColor: cor2,
                    }
                ]
            };

            const config = {
                type: 'line',
                data: data,
                options: {
                    responsive: true,
                    interaction: {
                        mode: 'index',
                        intersect: false,
                    },
                    stacked: false,
                    plugins: {
                        title: {
                            display: true,
                            text: 'Itens Ativos e Inativos',
                            color: 'white'
                        },
                        legend: {
                            display: true,
                            labels: {
                                color: 'white'
                            }
                        }
                    },
                    scales: {
                        y: {
                            type: 'linear',
                            display: true,
                            position: 'left',
                            ticks: {
                                color: 'white'
                            }
                        },
                        x: {

                            display: true,
                            ticks: {
                                color: 'white'
                            }
                        }
                    },
                    legend: {
                        labels: {
                            color: "white"
                        }
                    }
                },
            };

            const chartAtivoInativo = new Chart(document.getElementById('chartAtivoInativo'), config);
        }
    });
}

function gerarChartLicencas() {
    $.ajax({
        url: '/Home/GetChartLicencas/',
        type: 'POST',
        async: false,
        success: function (result) {
            result = JSON.parse(result);

            const data = {
                labels: result.Anos,
                datasets: [{
                    label: 'Itens comprados',
                    data:result.Compra,
                    fill: true,
                    backgroundColor: 'rgba(255, 99, 132, 0.2)',
                    borderColor: 'rgb(255, 99, 132)',
                    pointBackgroundColor: 'rgb(255, 99, 132)',
                    pointBorderColor: '#fff',
                    pointHoverBackgroundColor: '#fff',
                    pointHoverBorderColor: 'rgb(255, 99, 132)'
                }, {
                    label: 'Itens alugados',
                    data: result.Aluguel,
                    fill: true,
                    backgroundColor: 'rgba(54, 162, 235, 0.2)',
                    borderColor: 'rgb(54, 162, 235)',
                    pointBackgroundColor: 'rgb(54, 162, 235)',
                    pointBorderColor: '#fff',
                    pointHoverBackgroundColor: '#fff',
                    pointHoverBorderColor: 'rgb(54, 162, 235)'
                }]
            };

            const config = {
                type: 'radar',
                data: data,
                options: {
                    responsive: true,
                    maintainAspectRatio: false,
                    plugins: {
                        title: {
                            display: false,
                            text: 'Tipos de Licenças',
                            color: 'white'
                        },
                        legend: {
                            display: true,
                            labels: {
                                color: 'white'
                            }
                        }
                    },
                    scales: {
                        r: {
                            angleLines: {
                                display: false
                            },
                            ticks: {
                                color: 'white',
                                backdropColor: 'transparent',
                            },
                            pointLabels: {
                                color: "white",
                            }
                        },
                        
                    },
                    elements: {
                        line: {
                            borderWidth: 3
                        }
                    }
                },
                legend: {
                    labels: {
                        color: "white"
                    }
                }
            };

            const chartLicenca = new Chart(document.getElementById('licencasChart'), config);

        }
    });
}

function gerarCor() {
    var letras = '0123456789ABCDEF';
    var cor = "#";
    for (var i = 0; i < 6; i++) {
        cor += letras[Math.floor(Math.random() * 16)];
    }

    return cor;
}