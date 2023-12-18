$(document).ready(function(){
    
    (function($) {
        "use strict";

    
    jQuery.validator.addMethod('answercheck', function (value, element) {
        return this.optional(element) || /^\bcat\b$/.test(value)
    }, "type the correct answer -_-");

    // validate contactForm form
    $(function() {
        $('#contactForm').validate({
            rules: {
                name: {
                    required: true,
                    minlength: 2
                },
                phone: {
                    required: true,
                    minlength: 10
                },
                subject: {
                    required: true,
                    minlength: 2
                },
               
                email: {
                    required: true,
                    email: true
                },
                message: {
                    required: true,
                    minlength: 20
                }
            },
            messages: {
                name: {
                    required: "come on, you have a name, don't you?",
                    minlength: "your name must consist of at least 2 characters"
                },
                phone: {
                    required: "come on, you have a phone, don't you?",
                    minlength: "your name must consist of at least 10 characters"
                },
                subject: {
                    required: "come on, you have a subject, don't you?",
                    minlength: "your name must consist of at least 2 characters"
                },
                
                email: {
                    required: "no email, no message"
                },
                message: {
                    required: "um...yea, you have to write something to send this form.",
                    minlength: "thats all? really?"
                }
            },
            submitHandler: function (form) {
                $(form).ajaxSubmit({
                    type: "POST",
                    data: { name: _name, email: _email,phone: _phone, subject: _subject, message: _message },
                    url: "/Contact/Create",
                    success: function () {
                        $('#contactForm :input').attr('disabled', 'disabled');
                        
                            $('#success').fadeIn()
                       
                    },
                    error: function () {
                       {
                            $('#error').fadeIn()
                        }
                    }
                })
            }
        })
    })
        
 })(jQuery)
})