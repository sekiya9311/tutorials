package com.sekiya9311.viewgithubapp.service.repository

import com.sekiya9311.viewgithubapp.service.model.Project
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path

interface GitHubService {

    @GET("users/{user}/repos")
    fun getRepos(@Path("user") user: String): Call<List<Project>>

    @GET("/repos/{user}/{repoName}")
    fun getProject(@Path("user") user: String, @Path("repoName") repoName: String): Call<Project>

    companion object {
        val HTTPS_API_GITHUB_URL = "https://api.github.com/"
    }
}
