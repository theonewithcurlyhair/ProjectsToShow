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
        <title>Team</title>
        <%@include file="WEB-INF/jspf/head.jspf" %>
    </head>
    <body>
        <%@include file="WEB-INF/jspf/navigation.jspf" %>
        <h1 class="text-center display-4 grey">Team</h1>
        <section id="cover" class="min-vh-100 form-row justify-content-md-center">
            <div id="cover-caption">
                <c:set var="errors" value="${ error }" />
                <c:if test="${ createdTeam != null }">
                    <h3>Team Created with id: ${ createdTeam }</h3>
                </c:if>
                
                <form method="POST" action="team.jsp">
                    <c:if test="${ vm.team != null && vm.team.id !=0 }"> 
                        <tr>
                            <td><label>Team Id:</label></td>
                            <td> 
                                ${vm.team.id}
                                <input type="hidden" value='${vm.team.getId()}' name="hdnTeamId" />                                
                            </td>
                        </tr>
                    </c:if>
                    <div class="mb-3">
                        <label for="validationServer01">Team name</label>
                        <input type="text" class="form-control" name="teamName" placeholder="Team Name" required value="${vm.team.getName()}">
                        <!--                        <div class="valid-feedback">Looks good!</div>-->
                    </div>
                    <div class="mb-3">
                        <label for="validationServer02">First Team Member</label>
                        <select id="memberOne" name="memberOne" class="form-control">
                            <option value="0">--Please Select--</option>
                            <c:if test="${emps.size()!=0}">
                                <c:forEach items="${emps}" var="employee">
                                    <option value="${employee.getId()}">${employee.getName()}</option>
                                </c:forEach>
                            </c:if>
                        </select>
                    </div>

                    <div class="mb-3">
                        <label for="validationServer02">Second Team Member</label>
                        <select id="memberTwo" name="memberTwo" class="form-control">
                            <option value="0">--Please Select--</option>
                            <c:if test="${emps.size()!=0}">
                                <c:forEach items="${emps}" var="employee">
                                    <option value="${employee.getId()}">${employee.getName()}</option>
                                </c:forEach>
                            </c:if>
                        </select>
                    </div>

                    <input class="btn btn-lg btn-outline-dark" type="submit" value="create" name="action" />
            </div>
        </form>
        <div class="mt-5">
            <c:choose>
                <c:when test="${ team.errors.size() > 0 }">
                    <ul class="alert alert-danger">
                        <c:forEach items="${ team.errors }" var="err">
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