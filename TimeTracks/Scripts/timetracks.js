$( document ).ready(function() {
var errorContent = $('.validation-summary-errors').text();
if (errorContent.replace(/^\s+|\s+$/g,"") == '') { 
$('.validation-summary-errors').hide();
} else {
console.log('content');
}
});