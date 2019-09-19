Vue.component("order-status", {
    props:["orderStatus"],
    data:function(){
        return {};
    },
    template:"<span></span>"
});
Vue.component("order-pay", {
    props:["orderId"],
    data: function() {
        return {
            isPayed:false
        };
    },
    methods: {
        orderPayed: function() {

            var vueSelf = this;
            var xhr = new XMLHttpRequest();
            xhr.open("GET", "orders/" + vueSelf.orderId + "/payed", true);

            xhr.send();

            xhr.onload = function () {
                console.log(xhr.response);
                if (JSON.parse(xhr.response)) {
                    vueSelf.isShow = false;
                    var $orderStatusLabel = document.getElementById("order_status_" + vueSelf.orderId);
                    $orderStatusLabel.textContent = "Оплаченный";
                }
            };
        }
    },
    template:'<button v-show="!isPayed" class="btn btn-success" v-on:click="orderPayed()">Оплатить заказ</button>'
});

var vue = new Vue({
    el:'#orders'
});

function orderPayedWithJquery(orderId) {
    $.get("orders/" + orderId + "/payed", function(result) {
          if (!result)
             return;

          $("#button_" + orderId).hide();
          $("#order_status_" + orderId).text("Оплаченный");
    });
}

function orderPayed(orderId) {

    var xhr = new XMLHttpRequest();

    xhr.open("GET", "orders/" + orderId + "/payed", true);

    xhr.send();

    xhr.onload = function () {
        console.log(xhr.response);
        if (JSON.parse(xhr.response)) {
            var $button = document.getElementById("button_" + orderId);
            $button.style.display = 'none';
            var $orderStatusLabel = document.getElementById("order_status_" + orderId);
            $orderStatusLabel.textContent = "Оплаченный";
        }
    };
}