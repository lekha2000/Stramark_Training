function logBook(){
    const books = [];
    const ol = document.getElementById('order');
    const x = document.getElementById('txtbook').value;
    books.push(x);
    for (let i = 0; i < books.length; i++) {
        const element = "<li>" + books[i] + "</li>";
        ol.innerHTML += element;
    }
}