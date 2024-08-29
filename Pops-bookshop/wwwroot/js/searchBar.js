function filterBooks() {
    // get the value of the search input bar
    var query = document.getElementById("global-search-bar").value.toLowerCase();
    // get all the book divs
    var books = document.querySelectorAll(".book-item");

    books.forEach(function (book, index) {
        let title = book.querySelector(".book-title").textContent.toLowerCase();

        title = CustomisedTrim(title);

        let authors = book.querySelector(".book-authors").textContent.toLowerCase();

        //let authors = CustomisedTrim(authors);

        if (authors === "No author given") {
            authors = "";
        }

        let categories = book.querySelector(".book-categories").textContent.toLowerCase();

        //let categories = CustomisedTrim(categories);

        if (categories === "Category undefined") {
            categories = "";
        }

        let titleIncludes = title.includes(query);
        let authorsInclude = authors.includes(query);
        let categoriesInclude = categories.includes(query);

        if (!title.includes(query) && !authors.includes(query) && !categories.includes(query)) {
            book.style.display = "none";
        }
        else {
            book.style.display = "";
        }
    });
}

function CustomisedTrim(str) {
    let splitStr = str.split(/[\s,\n ]/);
    let splitStrNoEmpty = "";

    for (let i = 0; i < splitStr.length; i++) {
        if (splitStr[i] !== "") {
            splitStrNoEmpty += splitStr[i] + " ";
        }
    }

    if (splitStrNoEmpty.endsWith('info ')) {
        str = splitStrNoEmpty.slice(0, -6);
    }

    return str
}