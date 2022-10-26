
//import { signalR } from "../lib/microsoft/signalr/dist/browser/signalr.js"
//$(() => {
//    LoadStockData();
//    var connection = new signalR.HubConnectionBuilder().withUrl("/stocksHub").build();
//    connection.start();
//    connection.on("LoadStockData", function () {
//        LoadStockData();
//    })
//    LoadStockData();
//    function LoadStockData() {
//        var tr = '';

//        $.ajax({
//            URL: '/Stocks/GetStocks',
//            method: 'GET',
//            sucsses: (result) => {
//                $.each(result, (k, v) => {

//                })
//            },
//            error: (error) => {
//                console.log(error)
//            }
//        })

//    }
//})