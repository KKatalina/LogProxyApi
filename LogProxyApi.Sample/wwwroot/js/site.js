// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var sample = new Vue({
    el: '#app',
    data: {
        title: '',
        text: '',
        messages: [],
        infoMessage: "",
        errorMessage: ""
    },
    methods:
    {
        getMessages: function (event) {
            this.errorMessage = null;
            this.messages = [];
            this.$http.get('api/messages', function (data, status, request) {
                if (status == 200) {
                    this.messages = data;
                }
                else
                    this.errorMessage = 'Failed to load messages.'
            }).then( 
                (err) => {
                    if (!err.ok)
                        this.errorMessage = 'Failed to load messages.';
                })
                .catch((e) => {
                    this.errorMessage = 'Failed to load messages.';
                })
        },
        saveMessage: function (event) {
            this.errorMessage = null;
            this.$http.post('api/messages', { title: this.title, text: this.text }, function (data, status, request) {
                if (status == 200) {
                    this.infoMessage = 'New message with id "'+ data.id +'" was successfully created.';
                }
                else
                    this.errorMessage = 'Failed to create message.'
                this.title = '';
                this.text = '';
            }).then(
                (err) => {
                    if(!err.ok)
                        this.errorMessage = 'Failed to load messages.';
                })
                .catch((e) => {
                    this.errorMessage = 'Failed to load messages.';
                })
        }
    }
});