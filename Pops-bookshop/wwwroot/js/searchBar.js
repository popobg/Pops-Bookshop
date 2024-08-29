function filterBooks() {
    // get the value of the search input bar
    var query = document.getElementById("global-search-bar").value.toLowerCase();

    // get all the book divs
    var books = document.querySelectorAll(".book-item");

    books.forEach(function (book, index) {
        let title = book.querySelector(".book-title").textContent.toLowerCase();

        let authorsDivs = book.querySelectorAll(".book-authors");
        let authors = [...authorsDivs].map(e => e.textContent);

        if (authors[0] === "No author given") {
            authors = "";
        }

        let categoriesDivs = book.querySelectorAll(".book-categories");
        let categories = [...categoriesDivs].map(e => e.textContent);

        if (categories[0] === "Category undefined") {
            categories = "";
        }

        if (!title.includes(query) && !isQueryInList(query, authors) && !isQueryInList(query, categories)) {
            book.style.display = "none";
        }
        else {
            book.style.display = "";
        }
    });
}

function isQueryInList(query, list) {
    for (let i = 0; i < list.length; i++) {
        if (list[i].toLowerCase().includes(query)) {
            return true;
        }
    }
    return false;
}
