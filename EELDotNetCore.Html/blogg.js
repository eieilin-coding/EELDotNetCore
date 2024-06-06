const tblBlog = "blogs";

//getBlogTable();
//readBlog();
//createBlog();
//updateBlog("8306857c-264b-4bc3-9603-415ec465fa5d", 'abcdd', 'efgh','ijkl');
//deleteBlog("da8cf8cd-36df-4efc-a5b7-321f07369929");
//deleteBlog("33683139-95a3-4d48-99a6-40ccbd3b2297");

function readBlog(){
    let lst = getBlogs();
    console.log(lst);
}

function createBlog(title, author, content){
    let lst = getBlogs();
   
    const requestModel = {
        id: uuidv4(),
        title: title,
        author: author,
        content: content
    };

    lst.push(requestModel);

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    // localStorage.setItem("blogs", requestModel);

    successMessage("Saving Successful.");
    clearControls();
}

    function updateBlog(id, title , author, content){
      let lst = getBlogs();

     const items = lst.filter(x => x.id === id);
     console.log(items);

     console.log(items.length);
     if(items.length == 0){
        console.log("no data found.");
        return;
     }
    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;

    const index = lst.findIndex(x=> x.id === id);
    lst[index] = item;

    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    }
    
    function deleteBlog(id){
       let lst = getBlogs();
        const items = lst.filter(x => x.id === id);
        if(items.length == 0){
            console.log("no data found.");
            return;
        }

        lst = lst.filter(x => x.id !== id);
        const jsonBlog = JSON.stringify(lst);
        localStorage.setItem(tblBlog,jsonBlog);     
    }

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
    console.log(uuidv4());
  }
  function getBlogs(){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    return lst;
  }
  
  $('#btnSave').click(function(){
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();

    createBlog(title, author, content);
  })

  function successMessage(message){
    alert(message);
  }
  function errorMessage(message){
    alert(message);
  }
function clearControls(){
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus('');
}