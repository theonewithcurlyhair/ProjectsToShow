<%-- 
    Document   : teams
    Created on : Mar 31, 2020, 7:53:11 PM
    Author     : Mike
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>

<%@include file="WEB-INF/jspf/taglibraries.jspf" %>

<!DOCTYPE html>
<html>
    <head>
        <title>Employees</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">Employee</h1>
        <section>
            <div id="employeesView">

                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th scope="col">Team name</th>
                            <th scope="col">Team member 1</th>
                            <th scope="col">Team member 2</th>
                            <th scope="col">Was Deleted (but still has job)</th>
                            <th scope="col"></th>
                        </tr>
                    </thead>
                    <tbody>
                        <c:choose>
                            <c:when test="${ vm.size() > 0 }">
                                <c:forEach items="${ vm }" var="vm">
                                    <c:if test="${vm.getTeam().getDeletedAt() == null || vm.getTeam().getHasJob()}">
                                        <tr>
                                            <td>${vm.getTeam().getName()}</td>
                                            <td> <a href="/ATSWeb/employee/${vm.getTeamsEmployee().get(0).getId()}">${vm.getTeamsEmployee().get(0).getName()}</a></td>
                                            <td><a href="/ATSWeb/employee/${vm.getTeamsEmployee().get(1).getId()}">${vm.getTeamsEmployee().get(1).getName()}</a></td>
                                            <td>${vm.getTeam().getDeletedAt()}</td>
                                            <td><a href="#myModal" class="trigger-btn" data-toggle="modal">
                                                    <input class="btn btn-lg  btn-outline-dark" 
                                                           type="submit" 
                                                           value="Delete"
                                                           id="${vm.getTeam().getId()}" 
                                                           name="action" 
                                                           onClick="delete_click(this.id)"/>
                                                </a></td>
                                            <td><a href="#myModal" class="trigger-btn" data-toggle="modal">
                                                    <input class="btn btn-lg  btn-outline-dark" 
                                                           type="submit" 
                                                           value="onCall"
                                                           id="${vm.getTeam().getId()}" 
                                                           name="action" 
                                                           onClick="delete_click(this.id)"/>
                                                </a></td>

                                        </tr>
                                    </c:if>
                                </c:forEach>
                            </c:when>
                            <c:when test="${ vm.size() <= 0 || vm == null}">
                                <tr>
                                    <td colspan="8" style="text-align: center;">No teams were fond in the system</td>
                                </tr>
                            </c:when>
                        </c:choose>
                    </tbody>
                </table>
                <div class="mt-5">
                    <c:choose>
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

        <!-- Modal HTML -->
        <div id="myModal" class="modal fade">
            <div class="modal-dialog modal-confirm h-100 d-flex flex-column justify-content-center my-0">
                <form method="POST">
                    <div class="modal-content">
                        <div class="modal-header">			
                            <h4 class="modal-title">Are you sure?</h4>	
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        </div>
                        <div class="modal-body">
                            <p>Do you really want to delete this record? This process cannot be undone.</p>
                            <input type="hidden" class="form-control" name="id" id="deleteID">
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-info" data-dismiss="modal">Cancel</button>
                            <button type="submit" value="delete" name="action" class="btn btn-danger">Delete</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <script>
            function delete_click(clicked_id)
            {
                document.getElementById('deleteID').value = clicked_id;
            }
        </script>
    </body>
</html>
