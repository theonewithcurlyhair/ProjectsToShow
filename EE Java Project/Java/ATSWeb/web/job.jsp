<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Job</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
        <script>
            $(document).ready(function () {
                $("#task").select2({
                    placeholder: 'Select Tasks'
                });
            });
            $(document).ready(function () {
                $("#team").select2({
                    placeholder: 'Select Available Team'
                });
            });
        </script>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">Job</h1>
        <h2>${msg}</h2>
        <section id="cover" class="min-vh-100 form-row justify-content-md-center">
            <div id="cover-caption">
                <c:set var="errors" value="${ error }" />
                <form method="POST" action="job.jsp" id="jobForm">
                    <c:if test="${vmJob.job != null && vmJob.job.id !=0 }"> 
                        <h2 class="bg-success">Job Was Successfully Created</h2>
                        <tr>
                            <td><label>Job Id:</label></td>
                            <td> 
                                ${vmJob.job.getId()}
                                <input type="hidden" value='${vm.job.getId()}' name="hdnJobId" />                                
                            </td>
                        </tr>
                    </c:if>
                    <div class="mb-3">
                        <label for="validationServer01">Job Description</label>
                        <input id="description" type="text" class="form-control" name="description" placeholder="Job Description" required value="${vmJob.job.getDescription()}">
                    </div>
                    <div class="mb-3">
                        <label for="validationServer02">Client Name</label>
                        <input id="clientName" type="text" class="form-control" name='clientName' placeholder="Client Name"  required value="${vmJob.job.getClientName()}">
                    </div>


                    <!-- Add Job Tasks here, populate ddl with all the tasks -->
                    <div class="mb-3">
                        <label for="validationServer02">Select Job Tasks</label>
                        <select id="task" name="task" multiple data-style="bg-white rounded-pill px-4 py-3 shadow-sm " class="selectpicker w-100">
                            <option></option>
                            <c:if test="${vmTask.getTasks() != '[null]' && vmTask.getTasks().equals('[null]') ==false && vmTask.getTasks() != null && vmTask.getTasks().size() != 0 && vmTask != null && vmTask.equals('') == false && vmTask.getTasks().equals('') == false}">
                                <c:forEach items="${vmTask.getTasks()}" var="t">
                                    <option selected value="${t.getId()}">${t.getName()}</option>
                                </c:forEach>
                            </c:if>
                            <c:forEach items="${allTasks}" var="t">
                                <option value="${t.getId()}">${t.getName()}</option>
                            </c:forEach>
                        </select>
                    </div>

                    <!-- List tasks details after selection -->
                    <c:if test="${vmTask.getTasks() != '[null]' && vmTask.getTasks().equals('[null]') ==false && vmTask.getTasks() != null && vmTask.getTasks().size() != 0 && vmTask != null && vmTask.equals('') == false && vmTask.getTasks().equals('') == false}">
                        <strong>Task Details</strong>
                        <table class="table" id='taskDetailsTable'>
                            <tr>
                                <th>Name</th>
                                <th>Description</th>
                                <th>Duration</th>
                                    <c:if test="${vmJobTask.tasks != null && vmJobTask.tasks.size() > 0 && vmJobTask.tasks != '[null]' && vmJobTask.task.equals('[null]') == false && vmJobTask != null}">
                                    <th>Operating Cost</th>
                                    <th>Operating Revenue</th>
                                    </c:if>
                            </tr>
                            <c:choose>
                                <c:when test="${vmJobTask.tasks != null && vmJobTask.tasks.size() > 0 && vmJobTask.tasks != '[null]' && vmJobTask.task.equals('[null]') == false && vmJobTask != null}">
                                    <c:forEach var = "i" begin = "0" end = "${vmTask.tasks.size()-1}">
                                        <tr>
                                            <td>${vmTask.getTasks().get(i).getName()}</td>
                                            <td>${vmTask.getTasks().get(i).getDescription()}</td>
                                            <td>${vmTask.getTasks().get(i).getDuration()}</td>
                                            <td>${vmJobTask.getTasks().get(i).getOperatingCost()}</td>
                                            <td>${vmJobTask.getTasks().get(i).getOperatingRevenue()}</td>
                                        </tr>
                                    </c:forEach>
                                </c:when>
                                <c:otherwise>
                                    <c:forEach items="${vmTask.getTasks()}" var="t">
                                        <tr>
                                            <td>${t.getName()}</td>
                                            <td>${t.getDescription()}</td>
                                            5                                           <td>${t.getDuration()}</td>
                                        </tr>
                                    </c:forEach>
                                </c:otherwise>
                            </c:choose>
                        </table>
                    </c:if>


                    <div class="mb-3">
                        <label for="validationServer02">Job Start Date</label>
                        <div class="container">
                            <div class="row">
                                <div class='col-sm-6'>
                                    <div class="form-group">
                                        <div class='input-group date' id='startPicker'>
                                            <input type='text' id="startDateTime" class="form-control" name="start" value="${vmJob.getJob().getStart() != null ? vmJob.getJob().getStart() : ''}" 
                                                   placeholder="${vmJob.getJob().getStart() != null ? vmJob.getJob().getStartString() : ''}"
                                                   />
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="mb-3">
                        <label for="validationServer02">Job End Date</label>
                        <div class="container">
                            <div class="row">
                                <div class='col-sm-6'>
                                    <div class="form-group">
                                        <div class='input-group date' id='startPicker'>
                                            <input id="endDate" type='text' class="form-control" name="end" disabled value="${vmJob.getJob().getEnd() != null ? vmJob.getJob().getEndString() : ''}"/>
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Populate teams -->
                    <div class="mb-3">
                        <label for="validationServer02">Team</label>
                        <select id="team" name="team" data-style="bg-white rounded-pill px-4 py-3 shadow-sm" class="selectpicker w-100">
                            <option></option>
                            <c:if test="${teams.size()!=0}">
                                <c:forEach items="${teams}" var="team">
                                    <c:choose>
                                        <c:when test="${vmTeam.getTeam().getName().equals(team.getTeam().getName())}">
                                            <option value="${team.getTeam().getId()}" selected>${team.getTeam().getName()}</option>
                                        </c:when>
                                        <c:when test="${vmTeam.getTeam() != team.getTeam()}">
                                            <option value="${team.getTeam().getId()}">${team.getTeam().getName()}</option>
                                        </c:when>
                                    </c:choose>
                                </c:forEach>
                            </c:if>
                        </select>
                    </div>

<!--                    <input id="btnSubmit" class="btn btn-lg btn-outline-dark" type="submit" value="" name="action" />-->
                    <button id="btnSubmit" class="btn btn-lg btn-outline-dark" type="submit" value="" name="action" >Create Job</button>
            </div>
        </form>
        <div class="mt-5">
            <c:choose>
                <c:when test="${ job.errors.size() > 0 }">
                    <ul class="alert alert-danger">
                        <c:forEach items="${ job.errors }" var="err">
                            <li>Error Code: ${ err.code } Error Desc: ${err.description }</li>
                            </c:forEach>
                    </ul>
                </c:when>
                <c:when test="${ error!=null }">
                    <ul class="alert alert-danger">
                        <c:forEach items="${ error.errors }" var="err">
                            <li>${ err }</li>
                            </c:forEach>
                    </ul>
                </c:when>
            </c:choose>
        </div>
    </section>

    <%@include file="WEB-INF/jspf/footer.jspf" %>

    <script type="text/javascript">
        $(function () {
            $('#startPicker').datetimepicker();

            $("#startPicker").on("dp.hide", function (e) {
                var tasks = $('#task').val();
                if (tasks === null) {
                    tasks = "";
                }
                var stringifiedTasks = JSON.stringify(tasks);
                $.ajax({
                    type: 'POST',
                    url: 'job.jsp',
                    data: {startDateTime: e.date.toISOString(),
                        selectedTasks: stringifiedTasks,
                        team: $('#team').val(),
                        description: $('#description').val(),
                        clientName: $('#clientName').val(),
                    },
                    success: function (html) {
                        var newDoc = document.open("text/html", "replace");
                        newDoc.write(html);
                        newDoc.close();
                    },
                    dataType: 'html'
                });
            });
        });

        $('#task').on('change', function (e) {
            var tasks = $('#task').val();
            if (tasks === null) {
                tasks = "";
            }
            var stringifiedTasks = JSON.stringify(tasks);

            $.ajax({
                type: 'POST',
                url: 'job.jsp',
                data: {selectedTasks: stringifiedTasks,
                    team: $('#team').val(),
                    description: $('#description').val(),
                    clientName: $('#clientName').val()
                },
                success: function (html) {
                    var newDoc = document.open("text/html", "replace");
                    newDoc.write(html);
                    newDoc.close();
                },
                dataType: 'html'
            });
        });


        $('#team').change(function () {
            var tasks = $('#task').val();
            if (tasks === null) {
                tasks = "";
            }
            var stringifiedTasks = JSON.stringify(tasks);
            $.ajax({
                type: 'POST',
                url: 'job.jsp',
                data: {
                    selectedTasks: stringifiedTasks,
                    team: $('#team').val(),
                    description: $('#description').val(),
                    clientName: $('#clientName').val()
                },
                success: function (html) {
                    var newDoc = document.open("text/html", "replace");
                    newDoc.write(html);
                    newDoc.close();
                },
                dataType: 'html'
            });
        });

        $('#jobForm').submit(function (e) {
            e.preventDefault();
            var tasks = $('#task').val();
            if (tasks === null) {
                tasks = "";
            }
            var stringifiedTasks = JSON.stringify(tasks);
            console.log('serialized form');
            console.log($('#jobForm').serialize());
            
            $('#btnSubmit').val('create');
            $.ajax({
                type: 'POST',
                url: 'job.jsp',
                data: {
                    startDateTime: $('#startDateTime').attr('value'),
                    selectedTasks: stringifiedTasks,
                    team: $('#team').val(),
                    description: $('#description').val(),
                    clientName: $('#clientName').val(),
                    action: $('#btnSubmit').val()
                },
                success: function (html) {
                    var newDoc = document.open("text/html", "replace");
                    newDoc.write(html);
                    newDoc.close();
//                    $('#btnSubmit').val('');
//                    $("#jobForm")[0].reset();
//                    $('taskDetailsTable').innerHTML = '';
                },
                dataType: 'html'
            });
        });

    </script>
</body>
</html>