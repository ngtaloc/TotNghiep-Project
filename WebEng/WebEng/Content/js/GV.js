
﻿/* tạo modal thời gian biểu
=======
﻿// tạo modal thời gian biểu
function myFunction() {
    for (var i = 1; i <= parseInt($("#numbersofweek").val()); i++) {
        var stt_lesson = document.createElement("label");
        stt_lesson.textContent = "buổi " + i;
        var div_stt = document.getElementById("child");
        div_stt.appendChild(stt_lesson);
>>>>>>> refs/remotes/origin/main

//function myFunction() {
//    for (var i = 1; i <= parseInt($("#numbersofweek").val()); i++) {
//        var stt_lesson = document.createElement("label");
//        stt_lesson.textContent = "buổi " + i;
//        var div_stt = document.getElementById("child");
//        div_stt.appendChild(stt_lesson);

//        var p = document.createElement("select");
//        var div = document.getElementById("child");
//        div.appendChild(p);
//        p.style.height = "30px";
//        p.style.marginLeft = "10px";
//        p.name = "day";
//        for (var day = 1; day <= 7; day++) {
//            var option = document.createElement("option");
//            option.value = day;
//            switch (day) {
//                case 1: option.innerHTML = "Thứ hai";
//                    break;
//                case 2: option.innerHTML = "Thứ ba";
//                    break
//                case 3: option.innerHTML = "Thứ tư";
//                    break;
//                case 4: option.innerHTML = "Thứ năm";
//                    break
//                case 5: option.innerHTML = "Thứ sáu";
//                    break;
//                case 6: option.innerHTML = "Thứ bảy";
//                    break;
//                case 7: option.innerHTML = "Chủ nhật";
//                    break;
//            }
//            p.appendChild(option);
//        }
//        var startday = document.createElement("input");
//        startday.type = "time";
//        startday.style.height = "30px";
//        startday.style.marginLeft = "20px";
//        var div_input = document.getElementById("child");
//        div_input.appendChild(startday);

//        var endday = document.createElement("input");
//        endday.type = "time";
//        endday.style.height = "30px";
//        endday.style.marginLeft = "20px";
//        var div_input = document.getElementById("child");
//        div_input.appendChild(endday);

//        var br = document.createElement("br");
//        var br1 = document.getElementById("child");
//        br1.appendChild(br);
//    }
//}

//let perPage = 6;
//let currentPage = 1; 
//let start = 0;
//let end = perPage;

//const product = [
    
//    { image: "", nameTeacher: "ĐQuốc", job: "dev", nameClass: "Tên lớp", numBers: "Số lượng", startLearn: "Ngày khai giảng", Due: "Lịch học", numberMonths: "Thời gian khóa học", endLearn: "Ngày kết thúc" },  

//    { image: "" , nameTeacher: "Quốc", job: "dev", nameClass: "k23", numBers: "50", startLearn: "20", Due: "6", numberMonths: "6", endLearn: "3" },  

//    { image: "", nameTeacher: "Quốc", job: "dev", nameClass: "k23", numBers: "50", startLearn: "20", Due: "6", numberMonths: "6", endLearn: "3" }
//]

//let productArr = [];
//let showAdd = false;

//const image = document.getElementById('img');
//const nameTeacher = document.getElementById('nameTeacher');
//const job = document.getElementById('job');
//const nameClass = document.getElementById('nameClass');
//const numBers = document.getElementById('numBers');
//const startLearn = document.getElementById("startLearn");
//const Due = document.getElementById("Due");
//const numberMonths = document.getElementById("numberMonths");;
//const endLearn = document.getElementById("endLearn");
//const btnNext = document.querySelector('.btn-next');
//const btnPrev = document.querySelector('.btn-prev');

//function renderProduct() {
//    html = "";
//    const content = product.map((item, index) => {
//        if (index >= start && index < end) {
//            html += '<div class="item item1">';
//            html += '<div class="card card-widget widget-user-2 shadow-sm">';
//            html += '<div class="widget-user-header bg-warning">';
//            html += '<div id="img" class="widget-user-image">';
//            html += '<img src=' + item.image + '>';
//            html += '</div>';
//            html += '<h3 id="nameTeacher" class="widget-user-username">' + item.nameTeacher + '</h3>';
//            html += '<h5 id="job"class="widget-user-desc">' + item.job + '</h5>';
//            html += '</div>';
//            html += '<div class="card-footer p-0">';
//            html += '<ul class="nav flex-column">';
//            html += '<li class="nav-item" style="color:black">';
//            html += '<a id="nameClass"class="nav-link" style="pointer-events:none">';
//            html += item.nameClass;
//            html += '<span class="float-right badge bg-danger">842</span>';
//            html += '</a>';
//            html += '</li>';
//            html += '<li class="nav-item" style="color:black">';
//            html += '<a id="numBers" class="nav-link" style="pointer-events:none">';
//            html += item.numBers;
//            html += '<span class="float-right badge bg-danger">842</span>';
//            html += '</a>';
//            html += '</li>';
//            html += '<li class="nav-item" style="color:black">';
//            html += '<a id="startLearn" class="nav-link" style="pointer-events:none">';
//            html += item.startLearn;
//            html += ' <span class="float-right badge bg-danger">842</span>';
//            html += '</a>';
//            html += '</li>';
//            html += '<li class="nav-item" style="color:black">';
//            html += '<a id="Due" class="nav-link" style="pointer-events:none">';
//            html += item.Due;
//            html += ' <span class="float-right badge bg-danger">842</span>';
//            html += '</a>';
//            html += '</li>';
//            html += '<li class="nav-item" style="color:black">';
//            html += '<a id="Due" class="nav-link" style="pointer-events:none">';
//            html += item.numberMonths;
//            html += ' <span class="float-right badge bg-danger">842</span>';
//            html += '</a>';
//            html += '</li>';
//            html += '<li class="nav-item" style="color:black">';
//            html += '<a id="Due" class="nav-link" style="pointer-events:none">';
//            html += item.endLearn;
//            html += '<span class="float-right badge bg-danger">842</span>';
//            html += '</a>';
//            html += '</li>';
//            html += '<li class="nav-item" style="color:black; text-align:center">';
//            html += '<div class="row">';
//            html += '<div class="col-lg-6 col-md-6">';
//            html += '<button type="submit">';
//            html += '<i class="fas fa-user-edit"></i>';
//            html += ' </button>';
//            html += '</div>';
//            html += '<div class="col-lg-6 col-md-6">';
//            html += '<button id ="xoa" onclick = "delete()" type="submit">';
//            html += '<i class="fas fa-trash-alt"></i>';
//            html += '</button>';
//            html += '</div>';
//            html += '</div>';
//            html += '</li>';
//            html += '</ul>';
//            html += '</div>';
//            html += '</div>';
//            html += '</div>';
//            return html;
//        }
//    })
//    document.getElementById("wrap").innerHTML = html;
//}
//renderProduct();
//function getCurrentPage(currentPage) {
//    start = (currentPage - 1) * perPage;
//    end = currentPage * perPage;
//}
//const totalPages = Math.ceil(product.length / perPage); 
//btnNext.addEventListener('click', () => {
//    currentPage++;
//    if (currentPage > totalPages) {
//        currentPage = totalPages;
//    }
//    getCurrentPage(currentPage);
//    renderProduct();
//})

//btnPrev.addEventListener('click', () => {
//    currentPage--;
//    if (currentPage <= 1) {
//        currentPage = 1;
//    } 
//    getCurrentPage(currentPage);
//    renderProduct();
//})

//function renderListpage() {
//    let html = '';
//    html += '<li  class="active">';
//    html += '<a>' + 1 + '</a>';
//    html += '</li>';
//    for (let i = 2; i <= totalPages; i++) {
//        html += '<li  class="active">';
//        html += '<a>' + i + '</a>';
//        html += '</li>';
//    }
//    document.getElementById('number-page').innerHTML = html;
//}
//renderListpage();

//function changePages() {
//    const currentPages = document.querySelectorAll('.number-page li')
//    for (let i = 0; i <= currentPages.length; i++) {
//        currentPages[i].addEventListener('click', () => {
//            const value = i + 1;
//            currentPage = value;
//            getCurrentPage(currentPage);
//            renderProduct();
//        })
//    }
//}
//changePages();

//$("#xoa").click(function () {
//    $("div").remove();
//});*/