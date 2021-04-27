// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var sample = new Vue({
    el: '#app',
    data: {
        title: '',
        text: '',
        messages:[]
    },
    methods:
    {
        getMessages: function (event) {
            this.$http.get('api/messages', function (data, status, request) {
                if (status == 200) {
                    this.messages = data;
                }
            })
        },
        saveMessage: function (event) {
            this.$http.post('api/messages', { title: this.title, text: this.text }, function (data, status, request) {
                if (status == 200) {
                    this.messages = data;
                }
            })
        }
    }
});