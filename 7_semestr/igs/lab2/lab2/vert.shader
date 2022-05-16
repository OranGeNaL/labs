#version 330 core
layout (location = 0) in vec3 aPos;

uniform mat4 viewM;
uniform mat4 perspectiveM;
uniform mat4 modelM;

out vec4 ourColor;

void main()
{
    ourColor = vec4(aPos.x, aPos.y, aPos.z, 1.0);

    gl_Position = perspectiveM * viewM * modelM * vec4(aPos, 1.0f);

    //gl_Position = perspectiveM  * transform * vec4(aPos, 1.0f);
}
