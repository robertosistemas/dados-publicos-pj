$(function () {
    'use strict';

    let _dadoCadastral = abp.services.app.dadoCadastral,
        l = abp.localization.getSource('DadosPublicos');

    let _$pesquisarEmpresasInput = $('#pesquisarEmpresasInput');
    let _$pesquisarEmpresasButton = $('#pesquisarEmpresasButton');
    let _$pesquisarEmpresasDiv = $('#pesquisarEmpresasDiv');

    $(_$pesquisarEmpresasButton).on("click", function () {
        let value = $(_$pesquisarEmpresasInput).val();
        if (value == null || value.length == 0) {
            abp.message.info('Informe um nome ou CNPJ para pesquisar', 'Informações necessárias');
            return;
        }
        $(_$pesquisarEmpresasDiv).css("display", "block");
        PesquisarEstados();
    });

    let PesquisarEstados = function () {

        if ($.fn.DataTable.isDataTable('#pesquisarEmpresasTable')) {
            $('#pesquisarEmpresasTable').DataTable().destroy();
        }
        $('#pesquisarEmpresasTable tbody').empty();

        let _$pesquisarEmpresasTable = $('#pesquisarEmpresasTable');

        abp.ui.setBusy(_$pesquisarEmpresasDiv);

        //_dadoCadastral.getAllItems({
        //    sorting: 'Cnpj',
        //    referenceValues: $(_$pesquisarEmpresasInput).val(),
        //    direction: 'Asc',
        //    maxResultCount: 10
        //}

        //ajax: function (data, callback, settings) {
        //    callback({
        //        recordsTotal: result.totalCount,
        //        recordsFiltered: result.totalCount,
        //        data: [result]
        //    });
        //},

        _dadoCadastral.getByCnpj($(_$pesquisarEmpresasInput).val()).done(function (result) {

            console.log(result);

            if (result != null) {

                let pesquisarEmpresasTable = _$pesquisarEmpresasTable.DataTable({
                    paging: false,
                    serverSide: true,
                    ajax: function (data, callback, settings) {
                        callback({
                            recordsTotal: 1,
                            recordsFiltered: 1,
                            data: [result]
                        });
                    },
                    buttons: [
                        {
                            name: 'refresh',
                            text: '<i class="fas fa-redo-alt"></i>',
                            action: () => pesquisarEmpresasTable.draw(false)
                        }
                    ],
                    responsive: {
                        details: {
                            type: 'column'
                        }
                    },
                    columnDefs: [
                        {
                            targets: 0,
                            data: 'id',
                            sortable: false
                        },
                        {
                            targets: 1,
                            data: 'cnpj',
                            sortable: false
                        },
                        {
                            targets: 2,
                            data: 'razaoSocialNomeEmpresarial',
                            sortable: false
                        }
                    ]
                });
            }

        }).always(function () {
            abp.ui.clearBusy(_$pesquisarEmpresasDiv);
        });

    }

    /* ChartJS
     * -------
     * Here we will create a few charts using ChartJS
 
    let _dadoCadastral = abp.services.app.unidadeFederacao,
        l = abp.localization.getSource('DadosPublicos'),
        _$estadosTable = $('#EstadosTable');
 
    abp.ui.setBusy(_$estadosTable);
 
    _dadoCadastral.getAll({
        sorting: 'QuantidadeEmpresasAtivas DESC',
        skipCount: 0,
        maxResultCount: 50,
        mostrar: true
    }).done(function (result) {
 
 
        //-----------------------
        //- MONTHLY SALES CHART -
        //-----------------------
 
        let estados = [];
        let ativas = [];
        let inativas = [];
 
        for (let i = 0; i < result.items.length; i++) {
            let item = result.items[i];
            estados.push(item.codigo);
            ativas.push(item.quantidadeEmpresasAtivas);
            inativas.push(item.quantidadeEmpresasInativas);
        }
 
        // Get context with jQuery - using jQuery's .get() method.
        let salesChartCanvas = $('#salesChart').get(0).getContext('2d');
        // This will get the first returned node in the jQuery collection.
 
        let salesChartData = {
            labels: estados,
            datasets: [
                {
                    label: 'Empresas ativas por estados',
                    backgroundColor: 'blue',
                    borderColor: 'blue',
                    pointBackgroundColor: '#ced4da',
                    pointBorderColor: '#c1c7d1',
                    pointHoverBackgroundColor: '#fff',
                    pointHoverBorderColor: 'rgb(220,220,220)',
                    spanGaps: true,
                    data: ativas
                }
                //{
                //    label: 'Inativas',
                //    backgroundColor: 'red',
                //    borderColor: 'red',
                //    pointBackgroundColor: '#3b8bba',
                //    pointBorderColor: 'rgba(0, 123, 255, 1)',
                //    pointHoverBackgroundColor: '#fff',
                //    pointHoverBorderColor: 'rgba(0, 123, 255, 1)',
                //    spanGaps: true,
                //    data: inativas
                //}
            ]
        };
 
 
        let salesChartOptions = {
            //Boolean - If we should show the scale at all
            showScale: true,
            //Boolean - Whether grid lines are shown across the chart
            scaleShowGridLines: false,
            //String - Colour of the grid lines
            scaleGridLineColor: 'rgba(0,0,0,.05)',
            //Number - Width of the grid lines
            scaleGridLineWidth: 1,
            //Boolean - Whether to show horizontal lines (except X axis)
            scaleShowHorizontalLines: true,
            //Boolean - Whether to show vertical lines (except Y axis)
            scaleShowVerticalLines: true,
            //Boolean - Whether the line is curved between points
            bezierCurve: true,
            //Number - Tension of the bezier curve between points
            bezierCurveTension: 0.3,
            //Boolean - Whether to show a dot for each point
            pointDot: false,
            //Number - Radius of each point dot in pixels
            pointDotRadius: 4,
            //Number - Pixel width of point dot stroke
            pointDotStrokeWidth: 1,
            //Number - amount extra to add to the radius to cater for hit detection outside the drawn point
            pointHitDetectionRadius: 20,
            //Boolean - Whether to show a stroke for datasets
            datasetStroke: true,
            //Number - Pixel width of dataset stroke
            datasetStrokeWidth: 2,
            //Boolean - Whether to fill the dataset with a color
            datasetFill: true,
            //String - A legend template
            legendTemplate: '<ul class="<%=name.toLowerCase()%>-legend"><% for (let i=0; i<datasets.length; i++){%><li><span style="background-color:<%=datasets[i].lineColor%>"></span><%=datasets[i].label%></li><%}%></ul>',
            //Boolean - whether to maintain the starting aspect ratio or not when responsive, if set to false, will take up entire container
            maintainAspectRatio: false,
            //Boolean - whether to make the chart responsive to window resizing
            responsive: true
        };
 
        //Create the line chart
        let salesChart = new Chart(salesChartCanvas, {
            type: 'bar',
            data: salesChartData,
            options: salesChartOptions
        });
 
        //---------------------------
        //- END MONTHLY SALES CHART -
        //---------------------------
 
        let estadosTable = _$estadosTable.DataTable({
            paging: true,
            serverSide: true,
            ajax: function (data, callback, settings) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            },
            buttons: [
                {
                    name: 'refresh',
                    text: '<i class="fas fa-redo-alt"></i>',
                    action: () => estadosTable.draw(false)
                }
            ],
            responsive: {
                details: {
                    type: 'column'
                }
            },
            columnDefs: [
                {
                    targets: 0,
                    data: 'nome',
                    sortable: false
                },
                {
                    targets: 1,
                    data: 'quantidadeEmpresasAtivas',
                    sortable: false
                },
                {
                    targets: 2,
                    data: 'quantidadeEmpresasInativas',
                    sortable: false
                }
            ]
        });
 
    }).always(function () {
        abp.ui.clearBusy(_$estadosTable);
    });;
 
     */

});