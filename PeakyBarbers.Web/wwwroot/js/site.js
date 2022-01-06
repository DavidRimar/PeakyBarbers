// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// BOOK MODAL
$(function () {
    $('button.book-button').on('click', function () {

        $('#customer-book-modal').load(`/Booking/AppointmentList?handler=ShowBookModalPartial&id=${$(this).data('id')}`);

    });
})