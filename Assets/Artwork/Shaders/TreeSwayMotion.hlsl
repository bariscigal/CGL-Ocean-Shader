void TreeSwayMotion_float (float additionalNoise, float deltaSpeed,float offset,float radius, float3 vertexPos, float4 inVertexColor, float inTime, out float3 outVertPos){
            float noiseStrength = 0.1;

            float3 worldSpace = mul(unity_ObjectToWorld, vertexPos);
            float3 rotatedOffset = float3(0,0,0);
           // rotatedOffset.x = sin( inTime.x * deltaSpeed + worldSpace.z * offset) * radius * inVertexColor.r;
            rotatedOffset.y = sin( inTime.x * deltaSpeed + worldSpace.y * offset) * radius * inVertexColor.g * 15;
            rotatedOffset.y = (cos(inTime.x * deltaSpeed  + (worldSpace.x + additionalNoise  * noiseStrength) * offset) * radius * inVertexColor.r ) * 1;
            

            float3 outVertPosA = vertexPos;
            outVertPosA += mul(unity_WorldToObject, rotatedOffset);
            outVertPos = outVertPosA;
}

    