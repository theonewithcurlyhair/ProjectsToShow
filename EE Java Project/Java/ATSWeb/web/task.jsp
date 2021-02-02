<%-- 
    Document   : task
    Created on : 2-Mar-2020, 8:46:50 PM
    Author     : Nik
--%>
<%@include file="WEB-INF/jspf/taglibraries.jspf" %>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <title>Task</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">Task</h1>
        <section id="cover" class="min-vh-100 form-row justify-content-md-center">
            <div id="cover-caption">
                <c:set var="errors" value="${ error }" />
                <form method="POST" action="task.jsp">
                    <c:if test="${ vm.task != null && vm.task.id !=0 }"> 
                        <tr>
                            <td><label>Task Id:</label></td>
                            <td> 
                                ${vm.task.id}
                                <input type="hidden" value='${vm.task.getId()}' name="hdnTaskId" />                                
                            </td>
                        </tr>
                    </c:if>
                    <div class="mb-3">
                        <label for="validationServer01">Task name</label>
                        <input type="text" class="form-control" name="taskName" placeholder="Task Name" required value="${vm.task.getName()}">
                        <!--                        <div class="valid-feedback">Looks good!</div>-->
                    </div>
                    <div class="mb-3">
                        <label for="validationServer02">Task Description</label>
                        <input type="text" class="form-control" name='taskDesc' placeholder="Task Description"  required value="${vm.task.getDescription()}">
                    </div>
                    <div class="mb-3">
                        <label for="validationServer02">Duration</label>
                        <input type="text" class="form-control" name='taskDuration' placeholder="Task Duration"  required value="${vm.task.getDuration() != 0 ? vm.task.getDuration() : ''}">
                    </div>
                    <!--                    <button type="button" class="btn btn-lg btn-outline-dark">Create</button>-->
                    <c:if test="${vm.task != null}">
                        <input class="btn btn-lg btn-outline-dark" type="submit" value="update" name="action" />
                        <a href="#myModal" class="trigger-btn" data-toggle="modal">
                            <input class="btn btn-lg  btn-outline-dark" type="submit" value="delete" name="action" />
                        </a>
                    </c:if>
                    <c:if test="${vm.task == null}">
                        <input class="btn btn-lg btn-outline-dark" type="submit" value="create" name="action" />
                    </c:if>
            </div>
        </form>
        <div class="mt-5">
            <c:choose>
                <c:when test="${ task.errors.size() > 0 }">
                    <ul class="alert alert-danger">
                        <c:forEach items="${ task.errors }" var="err">
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
</body>
</html>